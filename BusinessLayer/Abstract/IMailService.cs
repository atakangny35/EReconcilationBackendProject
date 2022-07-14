using Core.Utilities.Abstract;
using EntityLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public interface IMailService
    {
        IResult SendMail(SendMailDto sendMailDto);
    }
}
