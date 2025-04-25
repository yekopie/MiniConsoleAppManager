using MiniConsoleAppManager.Tools.Abstract;
using MiniConsoleAppManager.Tools.Constants;

namespace MiniConsoleAppManager.Tools
{
    public class StringValidationBuilder : BaseValidationBuilder<StringValidationBuilder, string>
    {
        public StringValidationBuilder(string value) : base(value)
        {
            base._value = value;
        }

        public StringValidationBuilder MinLength(int minLength = int.MinValue)
        {
            base.ApplyValidation(() => base._value.Length < minLength, Messages.MinTextLength(minLength));

            return this;
        }

        public StringValidationBuilder MaxLength(int maxLength = int.MaxValue)
        {
            base.ApplyValidation(() => base._value.Length > maxLength, Messages.MaxTextLength(maxLength));

            return this;
        }


        public string WithMessage(string errorMsg)
        {
            return errorMsg;
        }

        public StringValidationBuilder IsInRange(int minValue, int maxValue)
        {
            base.ApplyValidation(() => _value.Length < minValue || _value.Length > maxValue, Messages.BeetwenValue(minValue, maxValue));

            return this;
        }

        public StringValidationBuilder CannotBeContain(string value)
        {
            base.ApplyValidation(() => _value.Contains(value), Messages.CannotContain(value));

            return this;
        }

        public StringValidationBuilder CannotBeNullOrWhiteSpace()
        {
            base.ApplyValidation(() => string.IsNullOrWhiteSpace(_value), Messages.NotSupported);

            return this;
        }
    }
}
