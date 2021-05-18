using Core.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Helper
{
   public interface IFileHelperService
    {
        public string Add(IFormFile file);
        public string Update(string sourcePath, IFormFile file);
        public IResult Delete(string path);
    }
}
