using System.Windows.Forms;

namespace FindReplacePlus.Classes
{
    public class RetinaTaskResponse
    {
        public RetinaTaskResponse(string msg, TreeNode node)
        {
            Message = msg;
            Node = node;
        }

        public string Message { get; }

        public TreeNode Node { get; }
    }
}
