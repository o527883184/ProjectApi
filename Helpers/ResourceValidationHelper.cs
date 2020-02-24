using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ProjectApi.Helpers
{
    /// <summary>
    /// 模型验证错误帮助类
    /// </summary>
    public class ResourceValidationHelper : Dictionary<string, IEnumerable<ResourceValidationError>>
    {
        public ResourceValidationHelper() : base(StringComparer.OrdinalIgnoreCase)
        {
        }

        public ResourceValidationHelper(ModelStateDictionary modelState) : this()
        {
            if (modelState == null)
                throw new ArgumentNullException(nameof(modelState));

            foreach (var keyModelStatePair in modelState)
            {
                var key = keyModelStatePair.Key;
                var errors = keyModelStatePair.Value.Errors;

                if (errors != null && errors.Count > 0)
                {
                    var errorsToAdd = new List<ResourceValidationError>();
                    foreach (var error in errors)
                    {
                        var arr = error.ErrorMessage.Split('|');
                        if (arr.Length > 1)
                            errorsToAdd.Add(new ResourceValidationError(arr[1], arr[0]));
                        else
                            errorsToAdd.Add(new ResourceValidationError(arr[0]));
                    }

                    Add(key, errorsToAdd);
                }
            }
        }
    }

    /// <summary>
    /// 模型验证错误类
    /// </summary>
    public class ResourceValidationError
    {
        public string ValidatorKey { get; set; }
        public string Message { get; set; }

        public ResourceValidationError(string message, string validatorKey = "")
        {
            ValidatorKey = validatorKey;
            Message = message;
        }
    }
}
