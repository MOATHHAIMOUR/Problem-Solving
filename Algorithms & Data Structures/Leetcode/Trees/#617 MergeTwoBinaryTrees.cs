public class Solution {
          public  void MergeNodesHelper(TreeNode root1, ref TreeNode root2)
       {
           if(root1 == null)
           {
               return;
           }
           else if (root1 == null && root2 == null)
           {
               return;
           }
           else if (root1 != null && root2 != null)
           {
               int sum = root2.val + root1.val;
               root2.val = sum;
           }
           else if (root1 != null && root2 == null)
           {
               root2 = new TreeNode(root1.val);
           }

           MergeNodesHelper(root1.left,ref root2.left);
           MergeNodesHelper(root1.right, ref root2.right);
       }

       public  TreeNode MergeTrees(TreeNode root1, TreeNode root2)
       {
           MergeNodesHelper(root1, ref root2);

           return root2;
       }
        
}
