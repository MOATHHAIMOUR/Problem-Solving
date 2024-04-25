 internal class Program
 {

        public static string GetPlaceValue(int lenght)
        {
            string placeval = "";

            if (lenght >= 17)
            {
                placeval = "quadrillion";
            }
            else if (lenght >= 14)
            {
                placeval = "trillion";
            }
            else if(lenght >= 10) 
            {
                placeval = "billion";
            }
            else if (lenght >= 7) 
            {
                placeval = "million";
            }
            else if (lenght >= 4) 
            {
                placeval = "thousand";
            }
            else
            {
                placeval = "";
            }

            return placeval; 
        } 

        public static string ConvertPlaceToWords(string number,string placeValue)
        {

            //speacial words for numbers
            //----------------------------------
            Dictionary<int, string> _1_To_9 = new Dictionary<int, string>  
            {
                 { 1, "One" },
                 { 2, "Two" },
                 { 3, "Three" },
                 { 4, "Four" },
                 { 5, "Five" },
                 { 6, "Six" },
                 { 7, "Seven" },
                 { 8, "Eight" },
                 { 9, "Nine" },
            };

            Dictionary<int, string> _11_To_19 = new Dictionary<int, string>
            {
                 { 11, "Eleven" },
                 { 12, "Twelve" },
                 { 13, "Thirteen" },
                 { 14, "Fourteen" },
                 { 15, "Fifteen" },
                 { 16, "Sixteen" },
                 { 17, "Seventeen" },
                 { 18, "Eighteen" },
                 { 19, "Nineteen" },
            };

            Dictionary<int, string> Tens = new Dictionary<int, string>()
            {
                { 10, "Ten" },
                { 20, "Twenty" },
                { 30, "Thirty" },
                { 40, "Forty" },
                { 50, "Fifty" },
                { 60, "Sixty" },
                { 70, "Seventy" },
                { 80, "Eighty" },
                { 90, "Ninety" }
            };
            //----------------------------------
            
            // all zerors case
            if (Convert.ToUInt32(number) == 0)
            {
                return ""; 
            }

            string numberToWord = "";

            if (Convert.ToInt32(number)>=100)
            {
                numberToWord += _1_To_9[number[0] - '0'] + " Hundred ";
            }

            int remaing = Convert.ToInt32(number[1].ToString() + number[2].ToString());

           
            if (_1_To_9.ContainsKey(remaing))
            {
                numberToWord+=_1_To_9[remaing];
            }
            else if (_11_To_19.ContainsKey(remaing))
            {
                numberToWord += _11_To_19[remaing];
            }
            else if (Tens.ContainsKey(remaing))
            {
                numberToWord += Tens[remaing];
            }          
            else
            {
                if (remaing != 0)
                {
                    int tens = Convert.ToInt32(number[1].ToString() + "0");
                    numberToWord += Tens[tens] + " " + _1_To_9[number[2] - '0'];
                }
            }

            numberToWord +=  " "  + placeValue + " , "; 

            return numberToWord;
        }

        public static string ConvertNumberToWord(string number)
        {

            string placeVal = "";
            string numberInWord = "";
            int charToDelete = 0;
            
            while(number.Length > 0)
            {
                placeVal = GetPlaceValue(number.Length);
                int val = number.Length % 3;

                if (val == 0)
                {
                    string num = number[0].ToString() + number[1].ToString() + number[2].ToString();
                    numberInWord += ConvertPlaceToWords(num, placeVal);
                    charToDelete = 3; 
                }
                else if(val == 1)
                {
                    string num = "0" + "0" + number[0].ToString();
                    numberInWord += ConvertPlaceToWords(num, placeVal);
                    charToDelete = 1;
                }
                else
                {
                    string num = "0" +  number[0].ToString() + number[1].ToString();
                    numberInWord += ConvertPlaceToWords(num, placeVal);
                    charToDelete = 2;
                }

                number = number.Remove(0, charToDelete);
                charToDelete = 0; 

            }

            //delete last ","
            numberInWord = numberInWord.Substring(0, numberInWord.Length-2);
            return numberInWord;
        }
 }
