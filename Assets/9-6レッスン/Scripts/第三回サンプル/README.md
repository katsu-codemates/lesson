# 第三回サンプルスクリプトについて

第三回(非同期処理・外部アセット導入・UnityWebRequestでの外部通信)で使うサンプル一式です。
9-6レッスンのプロジェクトに「オンラインランキング機能」を追加する想定で作っています。

## ファイル一覧

| ファイル | 役割 |
|---|---|
| `AsyncDemo.cs` | 導入パートで使う、非同期処理の必要性を体感してもらうためのデモ用スクリプト |
| `ExtensionMethods.cs` | `UnityWebRequest` を `await` できるようにする拡張メソッド |
| `ScoreData.cs` / `RankingEntry.cs` / `RankingResponse.cs` | サーバーとやり取りするJSONデータの型 |
| `ScoreService.cs` | GASのWeb APIにスコア送信・ランキング取得を行うサービスクラス |
| `GoalTrigger2D.cs` | ゴールに到達したら `GameManager2D916.Win()` を呼ぶトリガー |
| `RankingUI.cs` | 取得したランキングをTextMeshProで表示するだけのUI |
| `GameManager2D916_拡張版.cs` | 既存の `GameManager2D916.cs` に上記を組み込んだ参考実装(差分は `// 追加` コメント) |
| `Code.gs` | Googleスプレッドシートを簡易DBにするGoogle Apps Script側のサンプル(Unityプロジェクトには含めない) |

## 組み込み手順の目安

1. `Code.gs` の手順コメントに従ってGAS側のWebアプリを先にデプロイし、URLを控える
2. Unityプロジェクトにこのフォルダの `.cs` ファイル一式をインポートする
3. `GameManager2D916_拡張版.cs` を見ながら、既存の `GameManager2D916.cs` に `// 追加` 部分を組み込む
   (このファイル自体で既存スクリプトを上書きしない)
4. GameManagerオブジェクトに `ScoreService` コンポーネントを追加し、`webAppUrl` にGASのURLを設定する
5. ゴールオブジェクトに `GoalTrigger2D` を付け、`Is Trigger` にチェックを入れて `gameManager` を設定する
6. ランキング表示用のTextMeshProオブジェクトを作り、`RankingUI` にアタッチする

## 授業の流れとの対応

- 「非同期処理」パート → `AsyncDemo.cs`、`ExtensionMethods.cs`
- 「外部アセット導入」パート → スライド内でAsset Store/UPM経由の導入を実演(このフォルダには含まず)
- 「UnityWebRequestでの外部通信」パート → `ScoreService.cs` 以降のファイル一式、`Code.gs`
