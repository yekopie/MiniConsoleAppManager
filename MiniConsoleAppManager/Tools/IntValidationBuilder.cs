using MiniConsoleAppManager.Tools.Abstract;
using MiniConsoleAppManager.Tools.Constants;


namespace MiniConsoleAppManager.Tools
{
    public class IntValidationBuilder : BaseValidationBuilder<IntValidationBuilder, int>
    {
        public IntValidationBuilder(int value) : base(value)
        {
            base._value = value;
        }
        
        public IntValidationBuilder IsInRange(int minValue, int maxValue)
        {
            base.ApplyValidation(
                () => base._value < minValue || base._value > maxValue, 
                Messages.BeetwenTextLength(minValue, maxValue));

            return this;
        }

        public IntValidationBuilder CannotBeZero()
        {
            base.ApplyValidation(() => base._value.Equals(0), Messages.CannotBeZero);

            return this;
        }
        public IntValidationBuilder MustBePositive()
        {
            base.ApplyValidation(() => base._value < 0, Messages.MustBePositive);
            
            return this;
        }
        public IntValidationBuilder MustBeNegative()
        {
            base.ApplyValidation(() => base._value > 0, Messages.MustBeNegative);

            return this;
        }
        public IntValidationBuilder MustBeEven()
        {
            base.ApplyValidation(() => base._value % 2 is not 0, Messages.MustBeEven);
            
            return this;
        }

        public IntValidationBuilder MustBeOdd()
        {
            base.ApplyValidation(() => base._value % 3 is not 0, Messages.MustBeEven);

            return this;
        }
    }
}
