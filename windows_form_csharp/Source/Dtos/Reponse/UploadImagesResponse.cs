using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Source.Dtos.Image;

namespace Source.Dtos.Reponse
{
    public class UploadImagesResponse
    {
        public List<UploadImagesDTO> uploadImages { get; set; }
    }
}
