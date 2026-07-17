mac でC# GUI アプリ作成練習
- vscode
- Avalonia UI


## トラブルシューティング
vscodeにxamlのxamlライブビューイング拡張を入れたが、`command 'avalonia.showPreviewToSide`
解決→https://github.com/AvaloniaUI/AvaloniaPro/issues/17、　vscode versionあげる。

## ビルド・テスト



## 環境構築記録
.Net. SDKの確認
```
dotnet --version
```


Avalonia のテンプレートをインストール
```
dotnet new install Avalonia.Templates
```

プロジェクト作成
```
dotnet new avalonia.app -o projectname
```

実行
```
dotnet run
```

ignore fileの作成
```
dotnet new gitignore
```

コーディング規約ファイル
```
dotnet new editorconfig
```


