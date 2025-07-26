namespace ConsoleApp1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // NumIdenticalPairs([1, 1, 1, 1]);
            //  IsIsomorphic("paper", t: "title");
            //IsIsomorphic("badc", t: "baba");
            // CanConstruct();
            //ListNode cnode = new ListNode(3);
            //ListNode fnode = new ListNode(2);
            //fnode.next = cnode;

            //ListNode head = new ListNode(1);
            //ListNode node2 = new ListNode(2);
            //ListNode node3 = new ListNode(3);
            //ListNode node4 = new ListNode(4);
            //ListNode node5 = new ListNode(5);

            //// Link the nodes
            //head.next = node2;
            //node2.next = node3;
            //node3.next = node4;
            //node4.next = node5;
            //ListNode current = head;

            //// Print the linked list

            //// GetIntersectionNode(cnode, fnode);

            //RemoveNthFromEnd(head, 4);
            //int[] nums = [0, 0, 1, 1, 1, 2, 2, 3, 3, 4];
            //int[] nums = [0, 1, 2, 2, 3, 0, 4, 2];
            //var unielement = RemoveDuplicates(nums);
            //var k=RemoveElement(nums,2);

            //char[] s = "hello".ToCharArray();
            // ReverseString(s);

            //int[] nums = [7, 1, 5, 3, 6, 4];
            //var maxprofit=MaxProfit(nums);
            MoveZeroes([0, 1, 0, 3, 12]);
        }

        public static ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            //Ist solution
            //create a list that stores whole list
            //find out the targetIndex
            // test edge cases
            // then remove targetNode by -1 and next to targetNode.next

            //List<ListNode> listNodes = new List<ListNode>();

            //ListNode current = head;
            //while (current!=null)
            //{
            //    listNodes.Add(current);
            //    current = current.next;
            //}
            //int targetIndex = listNodes.Count - n;
            //if (targetIndex == 0)
            //{
            //    return head.next;
            //}

            //listNodes[targetIndex - 1].next = listNodes[targetIndex].next;

            //2nd solution
            //count all the nodes in the
            // then cal target node index
            // handle edge cased
            // count till target node
            //
            //int nodesCount = 0;
            //ListNode current = head;
            //ListNode iterator = head;
            //while (current != null) {
            //    nodesCount++;
            //    current=current.next;
            //}

            //int targetIndex = nodesCount - n;
            //if (targetIndex == 0)
            //{
            //    return head.next;
            //}
            //for(int i = 1; i < targetIndex; i++)
            //{
            //    iterator= iterator.next;
            //}
            //iterator.next = iterator.next.next;

            //3rd

            ListNode dummy = new ListNode(0);
            ListNode slow = dummy;
            ListNode fast = dummy;

            for (int i = 0; i <= n; i++)
            {
                fast = fast.next;
            }
            while (fast != null)
            {
                slow = slow.next;
                fast = fast.next;
            }

            slow.next = slow.next.next;

            return head;
        }

        public static int NumIdenticalPairs(int[] nums)
        {
            Dictionary<int, int> valuePairs = new();

            foreach (int i in nums)
            {
                if (valuePairs.ContainsKey(i))
                {
                    valuePairs[i] += 1;
                }
                else
                {
                    valuePairs[i] = 1;
                }
            }

            int totalPairs = 0;
            foreach (var pair in valuePairs)
            {
                totalPairs += (pair.Value * (pair.Value - 1)) / 2;
            }

            return totalPairs;
        }

        public static bool IsIsomorphic(string s, string t)
        {
            //        Input: s = "foo", t = "bar"
            //Output: false

            //  Input: s = "egg", t = "add"

            //Output: true

            Dictionary<char, char> keyValuePairs = new();

            bool isomorphic = true;
            for (int i = 0; i < s.Length; i++)
            {
                if (keyValuePairs.ContainsKey(s[i]))
                {
                    if (keyValuePairs[s[i]] != t[i])
                    {
                        isomorphic = false;

                        break;
                    }
                }
                else
                {
                    if (keyValuePairs.ContainsValue(t[i]))
                    {
                        isomorphic = false;

                        break;
                    }

                    keyValuePairs[s[i]] = t[i];
                }
            }

            return isomorphic;
        }

        public static bool CanConstruct(string ransomNote = "aa", string magazine = "ab")
        {
            Dictionary<char, int> ransomNoteCharPairs = new();
            Dictionary<char, int> magazineCharPairs = new();

            for (int i = 0; i < ransomNote.Length; i++)
            {
                if (ransomNoteCharPairs.ContainsKey(ransomNote[i]))
                {
                    ransomNoteCharPairs[ransomNote[i]] += 1;
                }
                else
                {
                    ransomNoteCharPairs[ransomNote[i]] = 1;
                }
            }
            for (int i = 0; i < magazine.Length; i++)
            {
                if (magazineCharPairs.ContainsKey(magazine[i]))
                {
                    magazineCharPairs[magazine[i]] += 1;
                }
                else
                {
                    magazineCharPairs[magazine[i]] = 1;
                }
            }

            foreach (var pair in ransomNoteCharPairs)
            {
                if (!magazineCharPairs.ContainsKey(pair.Key) || (magazineCharPairs.ContainsKey(pair.Key) && magazineCharPairs[pair.Key] < pair.Value))
                {
                    return false;
                }
            }
            return true;
        }

        public static ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {
            ListNode tempA = headA;
            ListNode tempB = headB;

            while (tempA != tempB)
            {
                tempA = tempA == null ? headB : tempA.next;
                tempB = tempB == null ? headA : tempB.next;
            }

            return tempA;
        }

        public static int RemoveDuplicates(int[] nums)
        {
            //var dic = new Dictionary<int, int>();
            //for (int i = 0; i < nums.Length; i++)
            //{
            //    if (!dic.ContainsKey(nums[i]))
            //    {
            //        dic.Add(nums[i], 1);
            //    }
            //}
            //for (int i = 0; i < dic.Count; i++)
            //{
            //    nums[i] = dic.ElementAt(i).Key;
            //}
            //return dic.Count;

            //var pointer = nums[0];
            //var counter = nums.Length>=1 ? 1 : 0;
            //for (int i = 1; i < nums.Length; i++)
            //{
            //    if (pointer != nums[i])
            //    {
            //        nums[counter]=nums[i];
            //        pointer = nums[counter];
            //        counter += 1;
            //    }
            //}
            //return counter;

            if (nums.Length == 0) return 0;
            var x = 0;
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] > nums[x])
                {
                    x++;
                    nums[x] = nums[i];
                }
            }
            return x + 1;
        }

        /// <summary>
        /// https://leetcode.com/problems/remove-element/description/
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public static int RemoveElement(int[] nums, int val)
        {
            int pointer1 = -1;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != val)
                {
                }
            }

            return pointer1 + 1;
        }

        /// <summary>
        /// https://leetcode.com/problems/reverse-string/
        /// </summary>
        /// <param name="s"></param>
        public static void ReverseString(char[] s)
        {
            //create two pointers
            //replace each other value
            //while pointer1<pointer2
            int startPointer = 0;
            int endPointer = s.Length - 1;
            while (startPointer < endPointer)
            {
                char tempChar = s[startPointer];
                s[startPointer] = s[endPointer];
                s[endPointer] = tempChar;
                startPointer++;
                endPointer++;
            }
        }

        /// <summary>
        /// https://leetcode.com/problems/best-time-to-buy-and-sell-stock/
        /// </summary>
        /// <param name="prices"></param>
        /// <returns></returns>
        public static int MaxProfit(int[] prices)
        {
            
            int maxProfit = 0;
            int pointer1 = prices[0];

            for (int i = 1; i < prices.Length; i++)
            {
                var tempProfit = prices[i] - pointer1;
                if (prices[i] < pointer1)
                {
                    pointer1 = prices[i];

                }
                if (tempProfit > maxProfit)
                {
                    maxProfit = tempProfit;
                }

            }
            return maxProfit;
        }

        /// <summary>
        /// https://leetcode.com/problems/move-zeroes/
        /// </summary>
        /// <param name="nums"></param>
        public static void MoveZeroes(int[] nums)
        {
            int emptyPositionIndex = -1;
            for(int i = 0; i < nums.Length; i++)
            {
                if (emptyPositionIndex < i && nums[i] != 0)
                {
                    emptyPositionIndex++;
                    nums[emptyPositionIndex]=nums[i];
                }
            }
            FillZeros(nums, ++emptyPositionIndex);

        }
        public static void FillZeros(int[] nums,int position)
        {
            for (int i = position; i < nums.Length; i++)
            {
                nums[i] = 0;
            }
        }

        public int FindMaxConsecutiveOnes(int[] nums)
        {

        }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;

        public ListNode(int x)
        {
            val = x;
        }
    }
}