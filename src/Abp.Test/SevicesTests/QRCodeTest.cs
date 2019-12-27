// ======================================================================
// 
//           Copyright (C) 2019-2030 ����������Ϣ�Ƽ����޹�˾
//           All rights reserved
// 
//           filename : QRCodeTest.cs
//           description :
// 
//           created by ѩ�� at  2019-11-06 11:39
//           �ĵ�������https://docs.xin-lai.com
//           ���ںŽ̳̣�����ļ���
//           QQȺ��85318032����̽�����
//           Blog��http://www.cnblogs.com/codelove/
// 
// ======================================================================

using System.IO;
using System.Threading.Tasks;
using Abp.Test;
using Magicodes.WxMiniProgram.Sdk.AccessToken;
using Magicodes.WxMiniProgram.Sdk.Services.QRCode;
using Magicodes.WxMiniProgram.Sdk.Services.Token;
using Newtonsoft.Json;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace Test.SevicesTests
{
    public class QRCodeTest : TestBase
    {
        public QRCodeTest(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
            _QRCodeAppService = Resolve<QRCodeAppService>();
        }

        private readonly ITestOutputHelper _testOutputHelper;
        private readonly QRCodeAppService _QRCodeAppService;

        [Fact]
        public async Task Create_Test()
        {
            var result = await _QRCodeAppService.Create("/test");
            result.Length.ShouldBeGreaterThan(0);
            await File.WriteAllBytesAsync(Path.Combine(Directory.GetCurrentDirectory(), nameof(Create_Test)+ ".jpg"),
                result);
        }

        [Fact]
        public async Task Get_Test()
        {
            var result = await _QRCodeAppService.Get("/test");
            result.Length.ShouldBeGreaterThan(0);
            await File.WriteAllBytesAsync(Path.Combine(Directory.GetCurrentDirectory(), nameof(Create_Test) + ".jpg"),
                result);
        }

        [Fact]
        public async Task GetUnlimited_Test()
        {
            var result = await _QRCodeAppService.GetUnlimited("232132132");
            result.Length.ShouldBeGreaterThan(0);
            await File.WriteAllBytesAsync(Path.Combine(Directory.GetCurrentDirectory(), nameof(Create_Test) + ".jpg"),
                result);
        }
    }
}