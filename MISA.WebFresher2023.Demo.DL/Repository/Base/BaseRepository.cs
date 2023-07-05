using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.WebFresher2023.Demo.Common.Constant;
using MISA.WebFresher2023.Demo.Common.MyException;
using MISA.WebFresher2023.Demo.Common.Resource;
using MISA.WebFresher2023.Demo.DL.Model;
using MySqlConnector;
using System.Data;
using System.Data.Common;

namespace MISA.WebFresher2023.Demo.DL.Repository
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity>
    {
        #region Field
        /// <summary>
        /// Chuỗi kết nối 
        /// </summary>
        /// Author: LeDucTiep (23/05/2023)
        protected readonly string _connectionString;
        #endregion

        #region Contructor
        public BaseRepository(IConfiguration configuration)
        {
            _connectionString = configuration["ConnectionString"] ?? "";
        }
        #endregion

        #region Method
        /// <summary>
        /// Hàm xóa một bản ghi
        /// </summary>
        /// <param name="id">Id của bản ghi</param>
        /// <returns>Số bản ghi đã xóa</returns>
        /// Author: LeDucTiep (23/05/2023)
        public virtual async Task<int> DeleteAsync(Guid id)
        {
            // Tên bảng 
            var table = typeof(TEntity).Name;

            // Tên procedure
            string procedure = ProcedureResource.Delete(table);

            // Connection với database 
            var connection = await GetOpenConnectionAsync();

            try
            {
                // Khởi tạo các tham số 
                var dynamicParams = new DynamicParameters();
                dynamicParams.Add($"{table}Id", id);

                var countChanged = await connection.ExecuteAsync(
                    procedure,
                    param: dynamicParams,
                    commandType: CommandType.StoredProcedure
                );

                return countChanged;
            }
            catch (Exception ex)
            {
                throw new InternalException();
            }
            finally
            {
                await connection.CloseAsync();
            }
        }

        /// <summary>
        /// Hàm xóa nhiều bản ghi
        /// </summary>
        /// <param name="id">Id của bản ghi</param>
        /// <returns>Số bản ghi đã xóa</returns>
        /// Author: LeDucTiep (23/05/2023)
        public virtual async Task<int> DeleteManyAsync(Guid[] arrayId)
        {
            // Số lượng bản ghi bị xóa
            int countChanged = 0;

            // Tên bảng 
            var table = typeof(TEntity).Name;

            // Tên procedure
            string procedure = ProcedureResource.DeleteMany(table);

            // Connection với database 
            var connection = await GetOpenConnectionAsync();

            try
            {
                // Chuyển thành dạng danh sách
                List<Guid> listId = arrayId.ToList();

                // Còn thở thì còn xóa
                while (listId.Count > 0)
                {
                    string param = "";
                    int counterFlag = 0;

                    // Xóa mỗi lần 10 bản ghi
                    while (listId.Count > 0 && counterFlag < 10)
                    {
                        Guid guid = listId[0];

                        param += $"'{guid}'";

                        listId.RemoveAt(0);

                        counterFlag++;

                        // Nếu là phần tử cuối cùng thì không cần dấu ,
                        if (listId.Count > 0 && counterFlag < 10)
                        {
                            param += ",";
                        }
                    }

                    // Khởi tạo các tham số 
                    var dynamicParams = new DynamicParameters();
                    dynamicParams.Add($"arrayId", param);

                    countChanged += await connection.ExecuteAsync(
                        procedure,
                        param: dynamicParams,
                        commandType: CommandType.StoredProcedure
                    );

                }
                return countChanged;
            }
            catch (Exception ex)
            {
                throw new InternalException();
            }
            finally
            {
                await connection.CloseAsync();
            }
        }

        /// <summary>
        /// Hàm lấy một bản ghi
        /// </summary>
        /// <param name="id">Id của bản ghi</param>
        /// <returns>Giá trị của bản ghi</returns>
        /// Author: LeDucTiep (23/05/2023)
        public virtual async Task<TEntity?> GetAsync(Guid id)
        {
            // Tên bảng
            var table = typeof(TEntity).Name;

            // Tên procedure
            string procedure = ProcedureResource.Get(table);

            // Kết nối với database
            var connection = await GetOpenConnectionAsync();
            try
            {
                // Tham số 
                var dynamicParams = new DynamicParameters();
                dynamicParams.Add($"{table}Id", id);

                // Bản ghi trả về 
                var entity = await connection.QueryFirstOrDefaultAsync<TEntity>(
                    procedure,
                    param: dynamicParams,
                    commandType: CommandType.StoredProcedure
                );

                return entity;
            }
            catch (Exception ex)
            {
                throw new InternalException();
            }
            finally
            {
                await connection.CloseAsync();
            }
        }

        /// <summary>
        /// Hàm tạo kết nối đến cơ sở dữ liệu
        /// </summary>
        /// <returns>Kết nối đến database</returns>
        /// Author: LeDucTiep (23/05/2023)
        public virtual async Task<DbConnection> GetOpenConnectionAsync()
        {
            try
            {
                // Tạo kết nối
                var connection = new MySqlConnection(_connectionString);

                // Mở kết nối 
                await connection.OpenAsync();

                // Trả về kết nối
                return connection;
            }
            catch
            {
                throw new InternalException(new() { (int)InternalErrorCode.ConnectDbError });
            }
        }

        /// <summary>
        /// Hàm thêm một bản ghi
        /// </summary>
        /// <param name="entity">Giá trị của bản ghi</param>
        /// <returns>Mã lỗi</returns>
        /// Author: LeDucTiep (23/05/2023)
        public virtual async Task<int> PostAsync(TEntity entity, Guid newId)
        {
            // Tên bảng
            var table = typeof(TEntity).Name;

            // Procedure
            string procedure = ProcedureResource.Add(table);

            // Mở kết nối tới database
            var connection = await GetOpenConnectionAsync();
            try
            {
                // Các tham số
                var dynamicParams = new DynamicParameters();

                //// Tạo id mới
                //Guid newId = Guid.NewGuid();

                var properties = entity.GetType().GetProperties();
                foreach (System.Reflection.PropertyInfo property in properties)
                {
                    // Tên thuộc tính
                    var name = property.Name;

                    // Gán id mới
                    if (name == $"{table}Id")
                    {
                        property.SetValue(entity, newId, null);

                        dynamicParams.Add($"{table}Id", newId);
                    }

                    // Bỏ qua ngày sửa và người sửa 
                    if (name == "ModifiedBy" || name == "ModifiedDate")
                        continue;

                    // Giá trị của tham số 
                    var value = property.GetValue(entity);

                    var type = property.PropertyType;

                    if ((type.Equals(typeof(Guid)) || type.Equals(typeof(Guid?))) && value.Equals(Guid.Empty))
                    {
                        dynamicParams.Add(name, null);
                    }
                    else
                    {
                        // Thêm tham số 
                        dynamicParams.Add(name, value);
                    }

                }

                // Thêm người tạo 
                dynamicParams.Add("CreatedBy", UserResource.Name);
                // Thêm ngày tạo 
                dynamicParams.Add("CreatedDate", DateTime.Now);


                using var myTransaction = await connection.BeginTransactionAsync();
                try
                {
                    //Gọi procedure
                    int changedCount = await connection.ExecuteAsync(
                        procedure,
                        param: dynamicParams,
                        commandType: CommandType.StoredProcedure,
                        transaction: myTransaction
                    );

                    myTransaction.Commit();

                    return changedCount;
                }
                catch (Exception ex)
                {
                    myTransaction.Rollback();
                    throw new InternalException();
                }
            }
            finally
            {
                // Đóng kết nối 
                await connection.CloseAsync();
            }
        }

        /// <summary>
        /// Hàm update một bản ghi
        /// </summary>
        /// <param name="id">Id của bản ghi</param>
        /// <param name="entity">Giá trị của bản ghi</param>
        /// <returns>Mã lỗi</returns>
        /// Author: LeDucTiep (23/05/2023)
        public virtual async Task<int> UpdateAsync(Guid id, TEntity entity)
        {
            // Tên bảng 
            var table = typeof(TEntity).Name;

            // Tên procedure
            string procedure = ProcedureResource.Update(table);

            // Mở kết nối tới database
            var connection = await GetOpenConnectionAsync();
            try
            {
                // Khởi tạo tham số 
                var dynamicParams = new DynamicParameters();

                // Duyệt qua tất cả thuộc tính của entity
                System.Reflection.PropertyInfo[] properties = entity.GetType().GetProperties();
                foreach (System.Reflection.PropertyInfo property in properties)
                {
                    // Tên tham số
                    var name = property.Name;

                    // Gán id truyền vào 
                    if (name == $"{table}Id")
                    {
                        dynamicParams.Add($"{table}Id", id);
                        continue;
                    }

                    // Bỏ qua người tạo và ngày tạo
                    if (name == "CreatedBy" || name == "CreatedDate")
                        continue;

                    // Giá trị của tham số 
                    var value = property.GetValue(entity);

                    if (value != null && value.Equals(Guid.Empty))
                    {
                        dynamicParams.Add(name, null);
                        continue;
                    }

                    // Thêm tham số
                    dynamicParams.Add(name, value);
                }

                // Thêm người sửa 
                dynamicParams.Add("ModifiedBy", UserResource.Name);

                // Thêm ngày sửa 
                dynamicParams.Add("ModifiedDate", DateTime.Now);

                using var myTransaction = await connection.BeginTransactionAsync();
                try
                {
                    // Gọi procedure
                    int changedCount = await connection.ExecuteAsync(
                        procedure,
                        param: dynamicParams,
                        commandType: CommandType.StoredProcedure,
                        transaction: myTransaction
                    );

                    myTransaction.Commit();

                    return changedCount;
                }
                catch (Exception ex)
                {
                    myTransaction.Rollback();
                    throw new InternalException();
                }
            }
            finally
            {
                // Đóng connection
                await connection.CloseAsync();
            }
        }

        /// <summary>
        /// Hàm lấy tất cả bản ghi
        /// </summary>
        /// <returns>Danh sách bản ghi</returns>
        /// Author: LeDucTiep (27/05/2023)
        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            // Tên bảng
            var table = typeof(TEntity).Name;

            // Tạo connection
            var connection = await GetOpenConnectionAsync();
            try
            {
                // Tên procedure
                string procedure = ProcedureResource.GetAll(table);

                // Gọi đến procedure
                return await connection.QueryAsync<TEntity>(
                    procedure,
                    commandType: CommandType.StoredProcedure
                );
            }
            catch
            {
                throw new InternalException();
            }
            finally
            {
                await connection.CloseAsync();
            }
        }

        public async Task<bool> CheckExistedAsync(Guid id, string table = "")
        {
            // Tên bảng
            if (table.Equals(string.Empty))
                table = typeof(TEntity).Name;

            // Kết nối với database
            var connection = await GetOpenConnectionAsync();
            try
            {
                // Tên procedure
                string procedure = ProcedureResource.CheckExistedById(table);

                // Tham số 
                var dynamicParams = new DynamicParameters();
                dynamicParams.Add($"{table}Id", id);

                // Bản ghi trả về 
                bool isExists = await connection.QueryFirstAsync<bool>(
                        procedure,
                        param: dynamicParams,
                        commandType: CommandType.StoredProcedure
                    );

                return isExists;
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                return false;
            }
            finally
            {
                await connection.CloseAsync();
            }
        }

        public virtual async Task<BasePage<TEntityInPage>> GetPageAsync<TEntityInPage>(BasePagingArgument basePagingArgument)
        {
            // Tạo connection
            var connection = await GetOpenConnectionAsync();

            string tableName = typeof(TEntity).Name;

            string procedure = ProcedureResource.GetPaging(tableName);

            try
            {
                // Tạo tham số đầu vào 
                // IN _offset: Số bản ghi bị bỏ qua
                // IN _limit: Số bản ghi được lấy
                // IN employeeSearchTerm: Từ khóa tìm kiếm, theo employeeCode hoặc FullName
                // OUT TotalRecord: Tổng số bản ghi tìm thấy
                var parameters = new DynamicParameters();
                int offset = (basePagingArgument.PageNumber - 1) * basePagingArgument.PageSize;
                parameters.Add("_offset", offset);
                parameters.Add("_limit", basePagingArgument.PageSize);
                parameters.Add("searchTerm", basePagingArgument.SearchTerm ?? "");
                parameters.Add("totalRecord", dbType: DbType.Int32, direction: ParameterDirection.Output);

                try
                {

                    // Gọi procedure 
                    IEnumerable<TEntityInPage> res = await connection.QueryAsync<TEntityInPage>(
                        procedure,
                        param: parameters,
                        commandType: CommandType.StoredProcedure
                    );

                    // Lấy tổng số trang 
                    var totalRecord = parameters.Get<int>("totalRecord");

                    // trả về kết quả
                    return new BasePage<TEntityInPage>(totalRecord, res);
                }
                catch (Exception ex)
                {
                    await Console.Out.WriteLineAsync(ex.Message);
                    return null;
                }
            }
            finally
            {
                // Dong connection
                await connection.CloseAsync();
            }
        }
        #endregion
    }
}
