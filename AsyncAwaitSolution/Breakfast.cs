using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAwaitSolution
{
    public class Breakfast
    {
        public async Task MakeBreakfastDemo()
        {
            Console.WriteLine("開始做早餐：" + DateTime.Now.ToString("HH:mm:ss"));

            // 這三行代碼執行時，三個任務就已經開始運行了
            Task<Toast> toastTask = ToastBreadAsync();    // 需要 3 秒

            // 此時在這await的話 就是要等它直行完才會往下執行
            //var toast = await toastTask;

            Task<Egg> eggsTask = FryEggsAsync();         // 需要 4 秒

            //var eggs = await eggsTask;

            Task<Bacon> baconTask = FryBaconAsync();      // 需要 5 秒

            //var bacon = await baconTask;

            Console.WriteLine("已經開始烤麵包、煎蛋、煎培根：" + DateTime.Now.ToString("HH:mm:ss"));

            // 雖然等待是按順序的，但任務已經開始執行了
            var toast = await toastTask;
            Console.WriteLine("麵包完成：" + DateTime.Now.ToString("HH:mm:ss"));

            var eggs = await eggsTask;
            Console.WriteLine("蛋完成：" + DateTime.Now.ToString("HH:mm:ss"));

            var bacon = await baconTask;
            Console.WriteLine("培根完成：" + DateTime.Now.ToString("HH:mm:ss"));

            Console.WriteLine("全部完成：" + DateTime.Now.ToString("HH:mm:ss"));

        }

        // 模擬方法
        private async Task<Toast> ToastBreadAsync()
        {
            await Task.Delay(3000); // 烤 3 秒
            return new Toast();
        }

        private async Task<Egg> FryEggsAsync()
        {
            await Task.Delay(4000); // 煎 4 秒
            return new Egg();
        }

        private async Task<Bacon> FryBaconAsync()
        {
            await Task.Delay(5000); // 煎 5 秒
            return new Bacon();
        }

    }

    public class Toast { }
    public class Egg { }
    public class Bacon { }
}
