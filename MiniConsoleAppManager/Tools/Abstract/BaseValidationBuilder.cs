using MiniConsoleAppManager.Tools.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniConsoleAppManager.Tools.Abstract
{
    public abstract class BaseValidationBuilder<TBuilder, T>
    {
        protected List<string> _errors = new();
        protected T _value;
        protected bool _hasError;
        protected BaseValidationBuilder(T value)
        {
            _value = value;
        }
        protected TBuilder ApplyValidation(Func<bool> condition, string errorMsg)
        {
            if (_hasError) return (TBuilder)(object)this;

            if (condition())
            {
                _errors.Add(errorMsg);
                _hasError = true;
            }

            return (TBuilder)(object)this;
        }
        public bool HasError => _hasError;
        public IList<string> Errors => _errors;
        public TBuilder MustBeType()
        {
            ApplyValidation(() => _value?.GetType() != typeof(T), Messages.NotSupported);

            return (TBuilder)(object)this;
        }
        public TBuilder MustEqual(T value)
        {
            ApplyValidation(() => !_value.Equals(value), Messages.MustEqual(value));

            return (TBuilder)(object)this;
        }

    }
}
