namespace TemplateCreator.Features.Template.Match;

public static class MethodBuilder
{
    public static BaseSettings Build(Methods method)
    {
        switch (method)
        {
            case Methods.TemplateMatching: return new TemplateMatchingSettings();
            case Methods.FeatureMatching: return new FeatureMatchingSettings();
            default: throw new NotImplementedException(Enum.GetName(typeof(Methods), method));
        }
    }
}

public enum Methods
{
    TemplateMatching,
    ContourDetection,
    ColorDetection,
    FeatureMatching,
    ObjectDetection,
    DeepLearningDetection
}

public abstract class BaseSettings
{

}

public sealed class TemplateMatchingSettings : BaseSettings
{

}

public sealed class ContourDetectionSettings : BaseSettings
{

}

public sealed class ColorDetectionSettings : BaseSettings
{

}

public sealed class FeatureMatchingSettings : BaseSettings
{

}

public sealed class ObjectDetectionSettings : BaseSettings
{

}

public sealed class DeepLearningDetectionSettings : BaseSettings
{

}