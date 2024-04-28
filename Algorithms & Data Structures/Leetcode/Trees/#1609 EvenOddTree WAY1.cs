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

    
  
     public static void Insert(ref TreeNode tree , int key)
     {
         if (tree == null)
         {
             tree = new TreeNode(key);
             return;
         }

         Queue<TreeNode> queue = new Queue<TreeNode>();
         queue.Enqueue(tree);

         while (queue.Count != 0)
         {
             TreeNode temp = queue.Dequeue();

             if (temp.left == null)
             {
                 temp.left = new TreeNode(key);
                 break;
             }
             else
             {
                 queue.Enqueue(temp.left);
             }

             if (temp.right == null)
             {
                 temp.right = new TreeNode(key);
                 break;
             }
             else
             {
                 queue.Enqueue(temp.right);
             }
         }
     }


     public int Level = 0;
     public void fillTreeInDic(TreeNode root, ref Dictionary<int, List<int>> dic)
     {
         if (root == null)
         {
             return;
         }

         //even level
         if (dic.ContainsKey(Level))
         {
             dic[Level].Add(root.val);
         }
         else
         {
             dic.Add(Level, new List<int>() { root.val });
         }
         Level++;
         fillTreeInDic(root.left, ref dic);
         fillTreeInDic(root.right, ref dic);
         Level--;

     }

     public bool IsEvenOddTree(TreeNode root)
     {
         var dic = new Dictionary<int, List<int>>();

         fillTreeInDic(root, ref dic);

         if (!(dic[0][0] % 2 != 0))
         {
             return false;
         }

         for (int i = 1; i < dic.Count; i++)
         {
             if (i % 2 == 0)
             {
                 if (dic[i].Count == 1)
                 {
                     if (!(dic[i][0] % 2 != 0))
                     {
                         return false;
                     }
                 }

                 for (int z = 0; z < dic[i].Count - 1; z++)
                 {

                     if (!((dic[i][z] % 2 != 0) && (dic[i][z + 1] % 2 != 0) && (dic[i][z] < dic[i][z + 1])))
                     {
                         return false;
                     }
                 }
             }
             else
             {
                 if (dic[i].Count == 1)
                 {
                     if (!(dic[i][0] % 2 == 0))
                     {
                         return false;
                     }

                 }

                 for (int z = 0; z < dic[i].Count - 1; z++)
                 {

                     if (!((dic[i][z] % 2 == 0) && (dic[i][z + 1] % 2 == 0) && (dic[i][z] > dic[i][z + 1])))
                     {
                         return false;
                     }
                 }

             }
         }

         return true;
     }


 }
