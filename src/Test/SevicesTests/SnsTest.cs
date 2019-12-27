// ======================================================================
// 
//           Copyright (C) 2019-2030 ����������Ϣ�Ƽ����޹�˾
//           All rights reserved
// 
//           filename : SnsTest.cs
//           description :
// 
//           created by ѩ�� at  2019-11-06 17:40
//           �ĵ�������https://docs.xin-lai.com
//           ���ںŽ̳̣�����ļ���
//           QQȺ��85318032����̽�����
//           Blog��http://www.cnblogs.com/codelove/
// 
// ======================================================================

using System.Threading.Tasks;
using Magicodes.WxMiniProgram.Sdk.Services.Sns;
using Newtonsoft.Json;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace Test.SevicesTests
{
    public class SnsTest : TestBase
    {
        public SnsTest(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
            _snsAppService = Resolve<SnsAppService>();
        }

        private readonly ITestOutputHelper _testOutputHelper;
        private readonly SnsAppService _snsAppService;

        [Fact(Skip = "���Ȼ�ȡcode")]
        public async Task JscodeToSession_Test()
        {
            //��¼ƾ֤У��Code���Լ���С���򿪷������л�ȡ
            //wx.login({
            //    success: function(res) {
            //        if (res.code)
            //        {
            //            console.log(res.code)
            //        }
            //    }
            //})
            var result = await _snsAppService.JscodeToSession("001p0EE41cBD6L1KWLE41CZGE41p0EEl");
            _testOutputHelper.WriteLine(JsonConvert.SerializeObject(result));
            result.IsSuccess().ShouldBe(true);
            result.OpenId.ShouldNotBeNullOrWhiteSpace();
        }
    }
}