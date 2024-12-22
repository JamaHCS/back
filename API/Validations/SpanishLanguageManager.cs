using FluentValidation.Resources;

namespace API.Validations
{
    public class SpanishLanguageManager : LanguageManager
    {
        public SpanishLanguageManager()
        {
            AddTranslation("es", "EmailValidator", "'{PropertyName}' no es una dirección de correo electrónico válida.");
            AddTranslation("es", "GreaterThanOrEqualValidator", "'{PropertyName}' debe ser mayor o igual que '{ComparisonValue}'.");
            AddTranslation("es", "GreaterThanValidator", "'{PropertyName}' debe ser mayor que '{ComparisonValue}'.");
            AddTranslation("es", "LengthValidator", "'{PropertyName}' debe tener entre {MinLength} y {MaxLength} caracteres. Actualmente tiene {TotalLength} caracteres.");
            AddTranslation("es", "MinimumLengthValidator", "'{PropertyName}' debe ser mayor o igual que {MinLength} caracteres. Ingresó {TotalLength} caracteres.");
            AddTranslation("es", "MaximumLengthValidator", "'{PropertyName}' debe ser menor o igual que {MaxLength} caracteres. Ingresó {TotalLength} caracteres.");
            AddTranslation("es", "LessThanOrEqualValidator", "'{PropertyName}' debe ser menor o igual que '{ComparisonValue}'.");
            AddTranslation("es", "LessThanValidator", "'{PropertyName}' debe ser menor que '{ComparisonValue}'.");
            AddTranslation("es", "NotEmptyValidator", "'{PropertyName}' no debería estar vacío.");
            AddTranslation("es", "NotEqualValidator", "'{PropertyName}' no debería ser igual a '{ComparisonValue}'.");
            AddTranslation("es", "NotNullValidator", "'{PropertyName}' es requerido.");
            AddTranslation("es", "PredicateValidator", "'{PropertyName}' no cumple con la condición especificada.");
            AddTranslation("es", "AsyncPredicateValidator", "'{PropertyName}' no cumple con la condición especificada.");
            AddTranslation("es", "RegularExpressionValidator", "'{PropertyName}' no tiene el formato correcto.");
            AddTranslation("es", "EqualValidator", "'{PropertyName}' debería ser igual a '{ComparisonValue}'.");
            AddTranslation("es", "ExactLengthValidator", "'{PropertyName}' debe tener una longitud de {MaxLength} caracteres. Actualmente tiene {TotalLength} caracteres.");
            AddTranslation("es", "ExclusiveBetweenValidator", "'{PropertyName}' debe estar entre {From} y {To} (exclusivo). Actualmente tiene un valor de {PropertyValue}.");
            AddTranslation("es", "InclusiveBetweenValidator", "'{PropertyName}' debe estar entre {From} y {To}. Actualmente tiene un valor de {PropertyValue}.");
            AddTranslation("es", "CreditCardValidator", "'{PropertyName}' no es un número de tarjeta de crédito válido.");
            AddTranslation("es", "ScalePrecisionValidator", "'{PropertyName}' no debe tener más de {ExpectedPrecision} dígitos en total, con margen para {ExpectedScale} decimales. Se encontraron {Digits} y {ActualScale} decimales.");
            AddTranslation("es", "EmptyValidator", "'{PropertyName}' debe estar vacío.");
            AddTranslation("es", "NullValidator", "'{PropertyName}' debe estar vacío.");
            AddTranslation("es", "EnumValidator", "'{PropertyName}' tiene un rango de valores que no incluye '{PropertyValue}'.");

            // Additional fallback messages used by client-side validation integration
            AddTranslation("es", "Length_Simple", "'{PropertyName}' debe tener entre {MinLength} y {MaxLength} caracteres.");
            AddTranslation("es", "MinimumLength_Simple", "'{PropertyName}' debe ser mayor o igual que {MinLength} caracteres.");
            AddTranslation("es", "MaximumLength_Simple", "'{PropertyName}' debe ser menor o igual que {MaxLength} caracteres.");
            AddTranslation("es", "ExactLength_Simple", "'{PropertyName}' debe tener una longitud de {MaxLength} caracteres.");
            AddTranslation("es", "InclusiveBetween_Simple", "'{PropertyName}' debe estar entre {From} y {To}.");
        }
    }
}
