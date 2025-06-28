using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Source.Dtos.Image
{
    public class UploadImagesDTO
    {
        public IFormFile[] files { get; set; }
        public string AltText { get; set; }
        public Guid ProductId { get; set; }
    }
}
