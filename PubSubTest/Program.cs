using Google.Apis.Auth.OAuth2;
using Google.Cloud.PubSub.V1;

const string projectId = "<...>";
const string subscriptionId = "<...>";
var credentials = GoogleCredential.FromJson("<...>");

var subscriberClient = new SubscriberClientImpl(
    new SubscriptionName(projectId, subscriptionId),
    new List<SubscriberServiceApiClient>
    {
        new SubscriberServiceApiClientBuilder { GoogleCredential = credentials }.Build()
    },
    new SubscriberClient.Settings(),
    () => Task.CompletedTask);

await subscriberClient.StartAsync((_, _) => Task.FromResult(SubscriberClient.Reply.Ack));
