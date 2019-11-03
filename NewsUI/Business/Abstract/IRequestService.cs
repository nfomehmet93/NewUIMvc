using NewsUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsUI.Bussines.Abstract
{
    public interface IRequestService
    {
        ResponseNewsModel GetNews(string uri);
        ResponseNewsDetailModel GetNewsDetail(string uri,int id=0,bool amp=false);
    }
}
