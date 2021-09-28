using System;
using Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Filters
{
    public class ApiResultResponseTypeFilter : Attribute, IAttributeGroup
    {
        public Attribute[] Process()
        {
            var attributes = new Attribute[]{
                new ProducesResponseTypeAttribute(typeof(ApiResult<string>), StatusCodes.Status200OK),
                new ProducesResponseTypeAttribute(typeof(ApiResult<string>), StatusCodes.Status400BadRequest),
                new ProducesResponseTypeAttribute(typeof(ApiResult<string>), StatusCodes.Status406NotAcceptable),
                new ProducesResponseTypeAttribute(typeof(ApiResult<string>), StatusCodes.Status415UnsupportedMediaType),
                new ProducesResponseTypeAttribute(typeof(ApiResult<string>), StatusCodes.Status500InternalServerError),
            };
            return attributes;
        }
    }
}
