﻿using CMS.Core.Data;
using CMS.Core.Entity;
using CMS.Core.Helper;
using CMS.Core.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace CMS.Core.Repository.Repo
{
    public class EmailsetupRepositoryImpl : BaseRepositoryImpl<EmailSetup>, EmailsetupRepository
    {
        private readonly AppDbContext _appDbContext;

        public EmailsetupRepositoryImpl(AppDbContext context, DetailsEncoder<EmailSetup> detailsEncoder, HtmlEncodingClassHelper htmlEncodingClassHelper) : base(context, detailsEncoder, htmlEncodingClassHelper)
        {
            _appDbContext = context;


        }

    }
}
