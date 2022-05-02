namespace TrackingComponents
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]

    public class TrackingPropertyAttribute : Attribute
    {
        public TrackingPropertyAttribute()
        {
        }

        public string MemberName { get; set; }
    }
}
