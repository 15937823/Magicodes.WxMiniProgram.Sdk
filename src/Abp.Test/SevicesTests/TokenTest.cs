// ======================================================================
// 
//           Copyright (C) 2019-2030 ����������Ϣ�Ƽ����޹�˾
//           All rights reserved
// 
//           filename : TokenTest.cs
//           description :
// 
//           created by ѩ�� at  2019-11-07 9:49
//           �ĵ�������https://docs.xin-lai.com
//           ���ںŽ̳̣�����ļ���
//           QQȺ��85318032����̽�����
//           Blog��http://www.cnblogs.com/codelove/
// 
// ======================================================================

using System.Threading.Tasks;
using Magicodes.WxMiniProgram.Sdk.Services.Token;
using Newtonsoft.Json;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace Abp.Test.SevicesTests
{
    public class TokenTest : TestBase
    {
        public TokenTest(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
            _tokenAppService = Resolve<TokenAppService>();
        }

        private readonly ITestOutputHelper _testOutputHelper;
        private readonly TokenAppService _tokenAppService;

        [Fact]
        public async Task Get_Test()
        {
            var result = await _tokenAppService.GetAsync();
            _testOutputHelper.WriteLine(JsonConvert.SerializeObject(result));
            result.IsSuccess().ShouldBe(true);
            result.AccessToken.ShouldNotBeNullOrWhiteSpace();
        }
    }
}