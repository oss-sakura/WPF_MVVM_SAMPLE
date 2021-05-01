/*
 * UpperLower.cs
 *
 * Copyright (c) 2021 IT SUPPORT SAKURA Co., Ltd.
 *
 * Released under the MIT license.
 * see https://opensource.org/licenses/MIT
 *
 */

namespace WpfMVVMSample.Model
{
    public class UpperLower
    {
        public UpperLower()
        {
        }

        public string Upper(string s)
        {
            if (string.IsNullOrEmpty(s)) { return string.Empty; }
            return s.ToUpper();
        }

        public string Lower(string s)
        {
            if (string.IsNullOrEmpty(s)) { return string.Empty; }
            return s.ToLower();
        }
    }
}
