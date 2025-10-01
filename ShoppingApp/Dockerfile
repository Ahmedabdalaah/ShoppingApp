# مرحلة البناء
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# نسخ ملف المشروع واستعادة الحزم
COPY *.csproj ./
RUN dotnet restore

# نسخ كل الملفات وبناء المشروع
COPY . ./
RUN dotnet publish -c Release -o out

# مرحلة التشغيل
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .

# تعيين البورت داخل الحاوية
EXPOSE 80

# نقطة البداية للتطبيق
ENTRYPOINT ["dotnet", "ShoppingApp.dll"]
