using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UniaMobile.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TreegexResult : ContentView
    {
        public string Text { get; set; }
        public TreegexResult()
        {
            InitializeComponent();
        }

        struct RegMatch
        {
            public int index;
            public string value;
            public bool regcap;
        }

        static Color
            selCol = Color.FromRgb(64, 94, 24),
            altCol = Color.FromRgb(24, 64, 94);

        public void SetData(string sampletext, string regex)
        {
            try
            {
                var nms = Regex.Matches(sampletext, $"[^{regex}]+").OfType<Match>().Select(n => new RegMatch { index = n.Index, value = n.Value, regcap = false });
                var ms = Regex.Matches(sampletext, regex).OfType<Match>().Select(n => new RegMatch { index = n.Index, value = n.Value, regcap = true });

                ResultContainer.Spans.Clear();
                var sst = ms.Union(nms).OrderBy(n => n.index).ToList();
                var s = 0;
                foreach (var m in sst)
                {
                    Span mt = new Span();
                    mt.Text = m.value;
                    if (m.regcap)
                    {
                        s++;
                        mt.BackgroundColor = s % 2 == 0 ? selCol : altCol;
                    }
                    ResultContainer.Spans.Add(mt);

                }
            }
            catch
            {
            }
        }
    }
}