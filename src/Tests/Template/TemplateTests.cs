using System;
using NUnit.Framework;

namespace Freddie.Tests.Template
{
    [TestFixture]
    public class TemplateTests : BaseTester
    {
        [Test]
        public void Can_templateAdd()
        {
            var args = new {
                html = "<div style=\"border:1px solid red;\">stuff</div><strong>HI!</strong>",
                name = Guid.NewGuid().ToString("n"),
            };

            var addResponse = tree.Do(x => x.Template.TemplateAdd(args));

            Assert.That(addResponse.Success, Is.True);
            Assert.That((int)addResponse.Content.value, Is.GreaterThan(0));
        }

        [Test]
        public void Can_templateDel()
        {
            var args = new
            {
                html = "<body>this is just going to get deleted anyway...</body>",
                name = Guid.NewGuid().ToString("n"),
            };

            var addResponse = tree.Do(x => x.Template.TemplateAdd(args));

            var id = (int)addResponse.Content.value;

            var delResponse = tree.Do(x => x.Template.TemplateDel(new { id }));

            Assert.That(delResponse.Success, Is.True);
        }

        [Test]
        public void Can_templateInfo()
        {
            var args = new
            {
                html = "<body>blarg</body>",
                name = Guid.NewGuid().ToString("n"),
            };

            var addResponse = tree.Do(x => x.Template.TemplateAdd(args));

            var tid = (int)addResponse.Content.value;

            var infoResponse = tree.Do(x => x.Template.TemplateInfo(new { tid }));

            Assert.That(infoResponse.Success, Is.True);
            Assert.That(infoResponse.Content.items["source"].Value, Contains.Substring(args.html));
        }

        [Test]
        public void Can_templateUpdate()
        {
            var add = new
            {
                html = "stuff",
                name = Guid.NewGuid().ToString("n"),
            };

            var addResponse = tree.Do(x => x.Template.TemplateAdd(add));

            var update = new
            {
                id = (int)addResponse.Content.value,
                values = new
                    {
                        html = "junk",
                        name = Guid.NewGuid().ToString("n"),
                    },
            };

            var updateResponse = tree.Do(x => x.Template.TemplateUpdate(update));

            Assert.That(updateResponse.Success, Is.True);

            var infoResponse = tree.Do(x => x.Template.TemplateInfo(new { tid = update.id }));

            string actual = infoResponse.Content.items["source"].Value;

            Assert.That(!actual.Contains(add.html));
            Assert.That(actual.EndsWith(update.values.html));
        }

        [Test]
        public void Can_templates()
        {
            var response = tree.Do(x => x.Template.templates());

            Assert.That(response.Success, Is.True);
            Assert.That(response.Content, Is.Not.Empty);
        }
    }
}
