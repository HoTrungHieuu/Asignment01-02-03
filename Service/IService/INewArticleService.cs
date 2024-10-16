﻿using BussinessObject.AddModel;
using BussinessObject.UpdateModel;
using Service.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IService
{
    public interface INewArticleService
    {
        public Task<ServiceResult> ViewAllNewsArticle();
        public Task<ServiceResult> ViewAllNewsArticleSearchPaging(string name, int sizePaging, int indexPaging);
        public Task<ServiceResult> ViewNewsArticleDetail(string newsArticleId);
        public Task<ServiceResult> AddNewsArticle(NewsArticleAdd key);
        public Task<ServiceResult> UpdateNewsArticle(NewsArticleUpdate key);
        public Task<ServiceResult> DeteleNewsArticle(string newsArticleId);
        public Task<ServiceResult> ViewStatistic(DateTime fromDate, DateTime toDate);
    }
}
