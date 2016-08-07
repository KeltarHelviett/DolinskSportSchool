using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DolinskSportSchool
{
    struct CardInfo
    {
        public int tableTag;
        public int recId;
        public Card self;

        public static bool operator ==(CardInfo ci1, CardInfo ci2)
        {
            if (ci1.recId == ci2.recId && ci1.tableTag == ci2.tableTag)
                return true;
            return false;
        }

        public static bool operator !=(CardInfo ci1, CardInfo ci2)
        {
            if (ci1.recId == ci2.recId && ci1.tableTag == ci2.tableTag)
                return false;
            return true;
        }
    }
    static class Notifier
    {
        static public List<TableForm> TableForms = new List<TableForm>();
        static public List<CardInfo> CardInfos = new List<CardInfo>();

        static public void LookAfterTable(TableForm tf)
        {
            TableForms.Add(tf);
        }

        static public void DropTable(TableForm tf)
        {
            TableForms.Remove(tf);
        }

        static public void LookAfterCard(Card c)
        {
            CardInfo ci = new CardInfo();
            ci.self = c;
            ci.tableTag = (int)c.Tag;
            ci.recId = c.CardId;
        }

        static public void DropCard(Card c)
        {
            CardInfo ci = new CardInfo();
            ci.self = c;
            ci.tableTag = (int)c.Tag;
            ci.recId = c.CardId;
            CardInfos.Remove(ci);
        }

        static public bool CheckCardExistence(int recId, int tableTag)
        {
            CardInfo ci = new CardInfo();
            ci.self = null;
            ci.tableTag = tableTag;
            ci.recId = recId;
            for (int i = 0; i < CardInfos.Count; i++)
            {
                if (CardInfos[i] == ci)
                {
                    CardInfos[i].self.Show();
                    return true;
                }
            }
            return false;
        }

        static public void UpdateTables()
        {
            for (int i = 0; i < TableForms.Count; i++)
            {
                TableForms[i].UpdateTable();
            }
        }
    }
}
