using Tests.Utils.Swd.BaseElements.Abstractions;

namespace Tests.Utils.Swd.BaseElements;

public class CheckBox : BaseElement
{
    public bool Marked => Selected;
    
    public void Mark()
    {
        if (!Marked)
        {
            Click();
        }
    }

    public void UnMark()
    {
        //TODO Marked return false
        if (Marked)
        {
            Click();
        }
    }
}