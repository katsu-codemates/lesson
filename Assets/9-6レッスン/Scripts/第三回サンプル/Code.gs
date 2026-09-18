// Google Apps Script: スプレッドシートを簡易DB代わりに使うスコアAPI
//
// 【事前準備】
// 1. 新しいスプレッドシートを作成し、シート名を「Ranking」にする
//    (1行目はヘッダーとして「playerName」「score」「timestamp」などを入れておくとよい)
// 2. 拡張機能 → Apps Script を開き、このコードを貼り付けて保存する
// 3. 右上の「デプロイ」→「新しいデプロイ」→ 種類の選択で「ウェブアプリ」を選ぶ
//    - 実行するユーザー: 自分
//    - アクセスできるユーザー: 全員
//    でデプロイする
// 4. 発行された「ウェブアプリのURL」を、Unity側の ScoreService.webAppUrl に設定する

function doPost(e) {
  var sheet = SpreadsheetApp.getActiveSpreadsheet().getSheetByName("Ranking");
  var data = JSON.parse(e.postData.contents);

  sheet.appendRow([data.playerName, data.score, new Date()]);

  return ContentService
    .createTextOutput(JSON.stringify({ result: "ok" }))
    .setMimeType(ContentService.MimeType.JSON);
}

function doGet(e) {
  var sheet = SpreadsheetApp.getActiveSpreadsheet().getSheetByName("Ranking");
  var rows = sheet.getDataRange().getValues();

  // 1行目がヘッダーの場合はここで除外(必要に応じて調整)
  var ranking = rows
    .filter(function (row) { return typeof row[1] === "number"; })
    .map(function (row) {
      return { playerName: row[0], score: row[1] };
    })
    .sort(function (a, b) { return b.score - a.score; })
    .slice(0, 10);

  return ContentService
    .createTextOutput(JSON.stringify({ ranking: ranking }))
    .setMimeType(ContentService.MimeType.JSON);
}
