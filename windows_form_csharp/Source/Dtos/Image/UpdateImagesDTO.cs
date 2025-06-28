using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Source.Dtos.Image
{
    public class UpdateImagesDTO
    {
        public Guid ProductId { get; set; }
        public IFormFile[] newFiles { get; set; }
        public IEnumerable<Guid> imageIdsToDelete { get; set; }
        public string AltText { get; set; }
    }
}
