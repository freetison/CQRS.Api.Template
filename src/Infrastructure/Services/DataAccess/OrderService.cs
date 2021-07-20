using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Entities.Sp;
using Domain.Entities.Tables;
using Domain.Services;
using $safeprojectname$.DataAccess.DbContext;

namespace $safeprojectname$.Services.DataAccess
{
    public class OrderService : IOrderService
    {

        private readonly AppDbContext _dbContext;

        public OrderService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<IEnumerable<Orders>> GetOrderBy(Expression<Func<Orders, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public Task<List<SpComplexDataFromDb>> GetActiveOrdersById(int orderId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> CreateOrder(Orders order)
        {
            _dbContext.Orders.Add(order);
            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}


//public async Task<IEnumerable<PartnerMinimalInfo>> GetPartnerBy(Expression<Func<Partners, bool>> predicate)
//{
//    var result = await _dbContext.Socios.Where(predicate)
//        .Select(s => new PartnerMinimalInfo()
//        {
//            IdPartner = s.IdSocio,
//            Idsubsidiary = s.IdSucursal,
//            IdUsersubsidiary = s.IdSucursalUsuario,
//            Name = s.Nombre,
//            Lastname = s.Apellido,
//            Picture = s.Foto
//        })
//        .ToListAsync();

//    return result;

//}

//public async Task<SpBuscarSocioByNumeroDocV2> GetPartnerByDoc(string dni)
//{
//    var sql = $@"EXEC dbo.{SpBuscarSocioByNumeroDocV2.DbSpName}  @numeroDoc = {dni} ";

//    var result = await _dbContext.SpBuscarSocioByNumeroDocV2.FromSqlRaw(sql).ToListAsync();


//    return result.FirstOrDefault().NothingIfNull();
//}

//public async Task<SpBuscarSocio> GetPartner(int idSocio, int idSucursal)
//{
//    var sql = $@"EXEC dbo.{SpBuscarSocio.DbSpName}  @idSocio = {idSocio}, @idSucursal = {idSucursal} ";

//    var result = await _dbContext.SpBuscarSocio.FromSqlRaw(sql).ToListAsync();


//    return result.FirstOrDefault().NothingIfNull();
//}

//public async Task<List<SpComplexDataFromDb>> GetActiveServiceByPartner(int idSocio, int idSucursalSocio)
//{
//    var sql = $@"EXEC dbo.{SpComplexDataFromDb.DbSpName}  @IdSocio = {idSocio},  @IdSucursalSocio = {idSucursalSocio}";

//    var result = await _dbContext.SpServiciosSociosListar.FromSqlRaw(sql).ToListAsync();

//    return result.NothingIfNull();
//}

//public async Task<SpWebApiTiendaSocioGetBasic> GetPartnerBasic(int doctType, Int32 docNumber)
//{
//    var sql = $@"EXEC dbo.{SpWebApiTiendaSocioGetBasic.DbSpName}  @TipoDocumento = {doctType},  @NumeroDocumento = {docNumber}";

//    var result = await _dbContext.SpWebApiTiendaSocioGetBasic.FromSqlRaw(sql).ToListAsync();

//    return result.FirstOrDefault().NothingIfNull();
//}