using IField;
using McDroid;
using I = IField;
using M = McDroid;

Sheep sheep = new Sheep();
I.Pig iPig = new I.Pig();
M.Pig mPig = new M.Pig();
Cow cow = new Cow();

namespace IField
{
    public class Sheep { }
    public class Pig { }

}

namespace McDroid
{
    public class Cow { }
    public class Pig { }
}