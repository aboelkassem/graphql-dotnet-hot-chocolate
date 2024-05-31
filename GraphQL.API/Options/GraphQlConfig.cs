namespace GraphQL.API.Options
{
    public class GraphQlConfig
    {
        public string GraphQlApiEndpoint { get; set; } = string.Empty;
        public string UiEndpoint { get; set; } = string.Empty;
        public bool ShowUi { get; set; }
        public string VisualNodesEndpoint { get; set; } = string.Empty;
        public bool ShowVisualNodes { get; set; }
    }
}
