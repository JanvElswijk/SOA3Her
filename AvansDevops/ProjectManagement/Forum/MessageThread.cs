using System.Text;

namespace AvansDevops.ProjectManagement.Forum;

public class MessageThread
{
    public BacklogItem BacklogItem;
    private Dictionary<int, Message> _messages;
    private bool _locked = false;
    
    public MessageThread(BacklogItem backlogItem)
    {
        BacklogItem = backlogItem;
        _messages = new Dictionary<int, Message>();
    }
    
    public void AddMessage(Message message)
    {
        if (BacklogItem.State is DoneBacklogItemState || _locked)
        {
            _locked = true;
            throw new InvalidOperationException("Cannot add messages to a thread of a done backlog item or a locked thread.");
        }
        
        int previousMessageId = _messages.Keys.Last();
        _messages.Add(++previousMessageId, message);
    }
    
    public void LockThread()
    {
        _locked = true;
    }
    
    public void UnlockThread()
    {
        _locked = false;
    }

    public override string ToString() {
        StringBuilder s = new StringBuilder();
        s.AppendLine($"Thread for Backlog Item: {BacklogItem.Title}");
        s.AppendLine("Messages:");
        foreach (var message in _messages.Values) {
            s.AppendLine(message.ToString());
        }

        s.AppendLine(_locked ? "Thread is locked." : "Thread is open for new messages.");
        return s.ToString();
    }
}