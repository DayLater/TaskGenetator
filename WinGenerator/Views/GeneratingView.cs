namespace WinGenerator.Views
{
    public class GeneratingView: View
    {
        public GeneratingView(string id)
        {
            Id = id;
        }

        public override string Id { get; }
        public override void Activate() { }
        public override void Deactivate() { }
    }
}