﻿using Domain.Entities;
using Domain.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.EFData
{
    class CommentDao : EfBaseDao<Comment>, ICommentRepository
    {
    }
}
