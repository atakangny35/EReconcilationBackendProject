using BusinessLayer.Abstract;
using BusinessLayer.Aspect;
using BusinessLayer.Constance;
using Core.entities.Concrete;
using Core.Utilities.Abstract;
using Core.Utilities.Concrete;
using DataAccesLayer.Abstract;
using EntityLayer.DTOs.OperationClaims;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
   public  class OperationClaimManager:IOperationClaimService
    {
        private readonly IOperationClaimDal operationClaimDal;
        public OperationClaimManager(IOperationClaimDal _operationClaimDal)
        {
            operationClaimDal = _operationClaimDal;
        }
        [SecuredOperations("Admin")]
        public IResult Add(OperationClaimsAddDto  operationClaimsAddDto)
        {
            var operationClaim = new OperationClaim
            {
                AddedTime = DateTime.Now,
                IsActive = operationClaimsAddDto.IsActive,
                Name = operationClaimsAddDto.Name,

            };

            operationClaimDal.add(operationClaim);

            return new SuccessResult(Constances.AddedCompany);    
        }
        [SecuredOperations("Admin")]
        public IResult Delete(int id)
        {

            operationClaimDal.Delete(operationClaimDal.Getitem(x => x.Id == id));
            return new SuccessResult(Constances.EntityDeleted);
        }
        [SecuredOperations("Admin")]
        public IDataResult<OperationClaim> getById(int id)
        {
            return new SuccesDataResult<OperationClaim>(operationClaimDal.Getitem(x => x.Id ==id));
        }
       // [SecuredOperations("Admin")]
        public IDataResult<List<OperationClaim>> GetList()
        {
            return new SuccesDataResult<List<OperationClaim>>(operationClaimDal.GetList());
        }
        [SecuredOperations("Admin")]
        public IResult Update(OperationClaimsUpdateDto  operationClaimsUpdateDto)
        {
          var operationClaim = operationClaimDal.Getitem(x => x.Id == operationClaimsUpdateDto.Id);
            
            if (operationClaim is null)
                return new ErrorResult("Kayıt bulunamadı");

            operationClaim.Name=operationClaimsUpdateDto.Name;
            operationClaim.IsActive = operationClaimsUpdateDto.IsActive;

            operationClaimDal.Update(operationClaim);
            return new SuccessResult(Constances.EntityUpdated);
        }
    }
}
