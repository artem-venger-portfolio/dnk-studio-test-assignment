mergeInto(LibraryManager.library, {
    RegisterCloseHandler: function() {
        window.onbeforeunload = function() {
            SendMessage('WebGLCloseWatcher', 'OnWebGLClose');
        };
    }
});