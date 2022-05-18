using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Abstract
{
    public interface ICommentManager
    {
        List<Comment> GetAllCommentById(int productId); 
        void AddComment(CommentDTO comment);
    }
}
