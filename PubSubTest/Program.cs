using Google.Apis.Auth.OAuth2;
using Google.Cloud.PubSub.V1;

const string projectId = "<...>";
const string subscriptionId = "<...>";
var credentials = GoogleCredential.FromJson("<...>");

var subscriberClient = new SubscriberClientBuilder
{
    GoogleCredential = credentials,
    SubscriptionName = SubscriptionName.FromProjectSubscription(projectId, subscriptionId)
}.Build();

await subscriberClient.StartAsync((_, _) => Task.FromResult(SubscriberClient.Reply.Ack));
