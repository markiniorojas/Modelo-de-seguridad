using System;

namespace Entitys.Models.Base
{
    public class BaseModel
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
