﻿using Swashbuckle.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Description;

namespace DataManagerService
{
    public class AuthorizationOperationFilter : IOperationFilter
    {
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            // Create the parameters if needed, otherwise add it to the collection.
            if (operation.parameters == null)
            {
                operation.parameters = new List<Parameter>();
            }

            operation.parameters.Add(new Parameter
            {
                name = "Authorization",
                @in = "header",
                description = "access token",
                required = false,
                type = "string"
            });
        }
    }
}