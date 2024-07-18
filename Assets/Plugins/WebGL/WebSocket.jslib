mergeInto(LibraryManager.library, {
    connectWebSocket: function(url, clientId) {
        var socket = new WebSocket("ws://localhost:8080/ws");
        
        socket.onopen = function(event) {
            console.log("WebSocket 연결 성공");
            // unityInstance.SendMessage('WebSocketManager', 'OnMessageReceived', 'WebSocket 연결 성공');
            
            // 클라이언트 ID를 서버로 전송
            var clientIdHeader = "X-Client-Id: " + clientId;
            socket.send(clientIdHeader);
        };
        
        socket.onmessage = function(event) {
            var message = event.data;
            unityInstance.SendMessage('WebSocketManager', 'OnMessageReceived', message);
        };
        
        socket.onerror = function(error) {
            console.error("WebSocket 오류:", error);
            unityInstance.SendMessage('WebSocketManager', 'OnMessageReceived', 'WebSocket 오류: ' + error.message);
        };
        
        socket.onclose = function(event) {
            console.log("WebSocket 연결 종료");
            unityInstance.SendMessage('WebSocketManager', 'OnMessageReceived', 'WebSocket 연결 종료');
        };

        window.webSocketInstance = socket;
    },

    sendWebSocketMessage: function(message) {
        if (window.webSocketInstance && window.webSocketInstance.readyState === WebSocket.OPEN) {
            window.webSocketInstance.send(message);
        } else {
            console.error("WebSocket이 연결되어 있지 않습니다.");
        }
    },

    closeWebSocket: function() {
        if (window.webSocketInstance) {
            window.webSocketInstance.close();
        }
    }
});