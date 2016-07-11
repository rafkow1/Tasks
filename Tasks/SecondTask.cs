using System;
using System.Collections.Generic;
using System.Linq;

namespace Tasks
{
    /// <summary>
    /// Class with second task about vizualizing differences between two strings.
    /// </summary>
    public class SecondTask
    {
        /// <summary>
        /// Description of public method.
        /// </summary>
        /// <param name="firstSentance">FirstParameter</param>
        /// <param name="secondSentence">SecondParameter</param>
        /// <returns>Mix of strings</returns>
        public string Mix(string firstSentance, string secondSentence)
        {
            string result = String.Empty;

            var dictionaryWithFirstSentence = ToDictionaryWithKeyOfAmountOfOccurancyLetter(FrequencyOfLowercaseLetters(firstSentance));
            var orderedDictionaryFirstSentence = dictionaryWithFirstSentence.OrderByDescending(x => x.Value);

            var dictionaryWithSecondSentence = ToDictionaryWithKeyOfAmountOfOccurancyLetter(FrequencyOfLowercaseLetters(secondSentence));
            var orderedDictionarySecondSentence = dictionaryWithSecondSentence.OrderByDescending(x => x.Value);

            var list = Max(orderedDictionaryFirstSentence, orderedDictionarySecondSentence);

            var listt11 = list.OrderByDescending(x => x.Length).ThenBy(x=>x).ToList();

            return ListToString(listt11);
        }
 
        private string ListToString(List<string> list)
        {
            string sentence = String.Empty;
            foreach(var word in list)
            {
                sentence += word;
            }

            return sentence.TrimStart('/');
        }

        private List<string> Max(IOrderedEnumerable<KeyValuePair<string,int>>collection1, IOrderedEnumerable<KeyValuePair<string,int>>collection2)
        {
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            List<string> list = new List<string>();

            foreach(var item in collection1)
            {
                dictionary.Add(item.Key, item.Value);
                list.Add(String.Format("/1:{0}", item.Key));
            }

            foreach(var item in collection2)
            {
                if (dictionary.ContainsKey(item.Key))
                {
                    list.Remove(String.Format("/1:{0}", item.Key));
                    list.Add(String.Format("/=:{0}", item.Key));
                }
                else
                {
                    list.Add(String.Format("/2:{0}", item.Key));
                }

                var findedStringFromCollection1 = list.Find(x=> x.StartsWith(String.Format("/1:{0}",item.Key[0])));
                var findedStringFromCollection2 = list.Find(x=> x.StartsWith(String.Format("/2:{0}",item.Key)));

               var smtList = (findedStringFromCollection1!= null && findedStringFromCollection1.Length > findedStringFromCollection2.Length) 
                    ? list.Remove(findedStringFromCollection2) 
                    : list.Remove(findedStringFromCollection1);
            }

           return list;
        }

        private Dictionary<string,int> FrequencyOfLowercaseLetters(string sentence)
        {
            Dictionary<string, int> frequencyOfLetters = new Dictionary<string, int>();
            
            foreach(var letter in sentence)
            {
                if (char.IsLower(letter))
                {
                    if (frequencyOfLetters.ContainsKey(letter.ToString()))
                    {        
                        frequencyOfLetters[letter.ToString()]++;
                    }
                    else
                    {
                        frequencyOfLetters.Add(letter.ToString(), 1);
                    }
                }
            }

            return frequencyOfLetters;
        }

        private Dictionary<string,int> ToDictionaryWithKeyOfAmountOfOccurancyLetter(Dictionary<string, int> dictionary)
        {
            Dictionary<string, int> frequencyOfLettersGraterThanOne = new Dictionary<string, int>();

            foreach (var item in dictionary)
            {
                string key = String.Empty;

                if (item.Value >= 2)
                {
                    for (int i = 1; i <= item.Value; i++)
                    {
                        key += item.Key;
                    }

                    frequencyOfLettersGraterThanOne.Add(key, item.Value);
                }
            }

            return frequencyOfLettersGraterThanOne;
        }
    }
}
