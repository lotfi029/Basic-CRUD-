$.validator.addMethod('filesize', function (value, element, param) {
    return this.optional(elemet) || element.files[0].size <= param;
});