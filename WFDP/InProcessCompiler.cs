using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using Microsoft.CSharp;

namespace WFDP
{
    // Внутрипроцессный компилятор
    public class InProcessCompiler
    {
        // Берём исходник
        public object CompileAndInstantiate(string sourceCode)
        {
            // Параметры компиляции
            var ps = new CompilerParameters
            {
                // Сборка в памяти
                GenerateInMemory = true,
                // dll
                GenerateExecutable = false
            };
            // Ссылки на любые сборки для вытягивания типов
            //ps.ReferencedAssemblies.Add("System.Drawing.dll");
            //ps.ReferencedAssemblies.Add("System.Core.dll");
            ps.ReferencedAssemblies.Add("WFDP.exe");

            // Настройки компилятора
            var po = new Dictionary<string,string>
            {{ "CompilerVersion","v4.0" }};

            // Создание провайдера
            var p = new CSharpCodeProvider(po);
            // Получение результатов компиляции из исходников sourceCode
            var result = p.CompileAssemblyFromSource(ps, sourceCode);

            // Берём скомпилированную сборку
            var ass = result.CompiledAssembly;
            // Берём первый тип сборки
            var mainType = ass.GetTypes()[0];
            // Активатором создаём экземпляр класса (Instance) этого типа
            return Activator.CreateInstance(mainType);
        }
    }
}