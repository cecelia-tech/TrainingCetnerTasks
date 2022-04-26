using TrackingComponents;

namespace Task02._3
{
    [TrackingEntity]
    public class Example
    {
        [TrackingProperty]
        public int ExampleProperty { get; set; } = 777;

        [TrackingProperty(MemberName = "Second example property name")]
        public string ExampleStringProperty { get; set; } = "bxhvbxjvjvn";
    }
}
