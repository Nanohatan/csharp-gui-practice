# mac でC# GUI・モバイルアプリ開発練習
- vscode
- MAUI

## プロダクトゴール
子供が子どもが店員役とお客さん役に分かれ、実際のお店のような注文体験を楽しめる

## 最初のリリース条件。
MVP、ユーザーが価値を感じられる最小構成
- 商品を登録できる
- カートに追加できる
- 注文できる（UI上だけ）
    - 注文ボタンを押すと、注文完了画面が表示される。データ送信や決済処理は行わない。

## プロダクトバックログ
1. 店員役のユーザーとして、商品を登録できる
1. 登録した商品を一覧で見れる
1. ？

## スプリントを設定する
- 開発→土日がメイン
- 金曜→日振り返り

## 最初のスプリントゴールを決める
- 1w 到達したい状態
    - ユーザーが商品を登録できる

## 進め方
- 作業を小さく分割
- スプリント終了時、毎回動く状態で終える
    - ビルドが通る状態で終える。
- スプリントの振り返りを行い、うまく行ったこと、詰まったこと、自習に変えることを考える。

- 大ゴール：商品を登録できる
- 優先高
    - [x] 商品登録ページを開ける
    - [x] 登録情報を入力できる  
    - [x] 入力した情報を見ることができる
- 優先低
    - [ ] 入力まわりテスト
    
## 疑問
- ファイル移動した後もビルドできた。どうやってパス参照してるんだ？
- ワークロードとテンプレートの違い何？
    - ワークロード：その種類のアプリを開発するために必要なツール一式
    - テンプレート：プロジェクトのひな型

## やってみたいこと
- format ローカルで自動で整える
    - エディタ設定


## トラブルシューティング
- vscodeにxamlのxamlライブビューイング拡張を入れたが、`command 'avalonia.showPreviewToSide`
    - 解決→https://github.com/AvaloniaUI/AvaloniaPro/issues/17、　vscode versionあげる。
- プロジェクトをリセットしたから、ci.yml一旦動かしたくない
    - コミットメッセージに[skip ci] を入れる。
- dotnet run でios選択後ビルドできない。
    - xcodeのパス`xcode-select -p`が`/Applications/Xcode.app/Contents/Developer`になるように。
    - https://developer.apple.com/documentation/xcode/configuring-command-line-tools-settings?changes=_8&utm_source=chatgpt.com
- `dotnet run -f net10.0-android`
    - android sdkを

## ビルド・テスト
- 依存ライブラリのインストール、ビルド、静的コードチェックを実装した。
- TODOテスト？もやるようにしたい。


## 環境構築記録
.Net. SDKの確認
```
dotnet --version
```


MAUI のテンプレートをインストール
```
dotnet workload install maui
```

プロジェクト作成
```
dotnet new maui -n OmamagotoApp
```

android sdk, java sdkの依存関係を導入
```
dotnet build \
  -t:InstallAndroidDependencies \
  -f net10.0-android \
  -p:AndroidSdkDirectory="$HOME/Library/Android/sdk" \
  -p:JavaSdkDirectory="$HOME/Library/Java/jdk" \
  -p:AcceptAndroidSDKLicenses=True
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


