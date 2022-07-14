using BusinessLayer.Abstract;
using BusinessLayer.Constance;
using Core.Utilities.Abstract;
using Core.Utilities.Concrete;
using DataAccesLayer.Abstract;
using EntityLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class MailManager : IMailService
    {
        private readonly IMailDal mailDal;

        public MailManager(IMailDal _mailDal)
        {
            mailDal = _mailDal;
        }

        public IResult SendMail(SendMailDto sendMailDto)
        {
            mailDal.SendMail(sendMailDto);
            return new SuccessResult(Constances.MailSended);
        }
    }
}
