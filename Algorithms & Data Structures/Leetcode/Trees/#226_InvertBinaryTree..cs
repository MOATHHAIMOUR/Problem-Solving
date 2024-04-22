 internal class Program
 {
      public class TreeNode
     {
         public int val;
         public TreeNode left;
         public TreeNode right;
         public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
         {
             this.val = val;
             this.left = left;
             this.right = right;
         }
     }

      public static void swapNode(ref TreeNode node1, ref TreeNode node2)
      {
         TreeNode temp = node1;
         node1 = node2;
         node2 = temp;
      }

      public static void InvertTree(ref TreeNode root)
      {
         if (root == null)
             return;

         swapNode(ref root.left, ref root.right);
         InvertTree(ref root.left);
         InvertTree(ref root.right);

      }

     
 }
